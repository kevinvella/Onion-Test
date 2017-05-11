/*  ********* TEMPORARILY HERE **************
 * - will be on npm soon -
 *   import { ngAspnetCoreEngine } from `@ng-universal/ng-aspnetcore-engine`;
 */
import { NgModuleFactory, ApplicationRef, CompilerFactory } from '@angular/core';
import { platformServer, platformDynamicServer, PlatformState, INITIAL_CONFIG } from '@angular/platform-server';
import { ResourceLoader } from '@angular/compiler';
import * as fs from 'fs';
import { REQUEST } from '../app/shared/constants/request';
import { ORIGIN_URL } from '../app/shared/constants/baseurl.constants';
// import { FileLoader } from './file-loader';
export function createTransferScript(transferData) {
    return "<script>window['TRANSFER_CACHE'] = " + JSON.stringify(transferData) + ";</script>";
}
var FileLoader = (function () {
    function FileLoader() {
    }
    FileLoader.prototype.get = function (url) {
        return new Promise(function (resolve, reject) {
            fs.readFile(url, function (err, buffer) {
                if (err) {
                    return reject(err);
                }
                resolve(buffer.toString());
            });
        });
    };
    return FileLoader;
}());
export { FileLoader };
;
export function ngAspnetCoreEngine(options) {
    options.providers = options.providers || [];
    var compilerFactory = platformDynamicServer().injector.get(CompilerFactory);
    var compiler = compilerFactory.createCompiler([
        {
            providers: [
                { provide: ResourceLoader, useClass: FileLoader }
            ]
        }
    ]);
    return new Promise(function (resolve, reject) {
        try {
            var moduleOrFactory = options.ngModule;
            if (!moduleOrFactory) {
                throw new Error('You must pass in a NgModule or NgModuleFactory to be bootstrapped');
            }
            var extraProviders = options.providers.concat(options.providers, [
                {
                    provide: INITIAL_CONFIG,
                    useValue: {
                        document: options.appSelector,
                        url: options.request.url
                    }
                },
                {
                    provide: ORIGIN_URL,
                    useValue: options.request.origin
                }, {
                    provide: REQUEST,
                    useValue: options.request.data.request
                }
            ]);
            var platform_1 = platformServer(extraProviders);
            getFactory(moduleOrFactory, compiler)
                .then(function (factory) {
                return platform_1.bootstrapModuleFactory(factory).then(function (moduleRef) {
                    var state = moduleRef.injector.get(PlatformState);
                    var appRef = moduleRef.injector.get(ApplicationRef);
                    appRef.isStable
                        .filter(function (isStable) { return isStable; })
                        .first()
                        .subscribe(function (stable) {
                        // Fire the TransferState Cache
                        var bootstrap = moduleRef.instance['ngOnBootstrap'];
                        bootstrap && bootstrap();
                        // The parse5 Document itself
                        var AST_DOCUMENT = state.getDocument();
                        // Strip out the Angular application
                        var htmlDoc = state.renderToString();
                        var APP_HTML = htmlDoc.substring(htmlDoc.indexOf('<body>') + 6, htmlDoc.indexOf('</body>'));
                        // Strip out Styles / Meta-tags / Title
                        var STYLES = [];
                        var META = [];
                        var LINKS = [];
                        var TITLE = '';
                        var STYLES_STRING = htmlDoc.substring(htmlDoc.indexOf('<style ng-transition'), htmlDoc.lastIndexOf('</style>') + 8);
                        // STYLES_STRING = STYLES_STRING.replace(/\s/g, '').replace('<styleng-transition', '<style ng-transition');
                        var HEAD = AST_DOCUMENT.head;
                        var count = 0;
                        for (var i = 0; i < HEAD.children.length; i++) {
                            var element = HEAD.children[i];
                            if (element.name === 'title') {
                                TITLE = element.children[0].data;
                            }
                            // Broken after 4.0 (worked in rc)
                            // if (element.name === 'style') {
                            //   let styleTag = '<style ';
                            //   for (let key in element.attribs) {
                            //     if (key) {
                            //       styleTag += `${key}="${element.attribs[key]}">`;
                            //     }
                            //   }
                            //   styleTag += `${element.children[0].data}</style>`;
                            //   STYLES.push(styleTag);
                            // }
                            if (element.name === 'meta') {
                                count = count + 1;
                                var metaString = '<meta';
                                for (var key in element.attribs) {
                                    if (key) {
                                        metaString += " " + key + "=\"" + element.attribs[key] + "\"";
                                    }
                                }
                                META.push(metaString + " />\n");
                            }
                            if (element.name === 'link') {
                                var linkString = '<link';
                                for (var key in element.attribs) {
                                    if (key) {
                                        linkString += " " + key + "=\"" + element.attribs[key] + "\"";
                                    }
                                }
                                LINKS.push(linkString + " />\n");
                            }
                        }
                        resolve({
                            html: APP_HTML,
                            globals: {
                                styles: STYLES_STRING,
                                title: TITLE,
                                meta: META.join(' '),
                                links: LINKS.join(' ')
                            }
                        });
                        moduleRef.destroy();
                    }, function (err) {
                        reject(err);
                    });
                });
            });
        }
        catch (ex) {
            reject(ex);
        }
    });
}
/* ********************** Private / Internal ****************** */
var factoryCacheMap = new Map();
function getFactory(moduleOrFactory, compiler) {
    return new Promise(function (resolve, reject) {
        // If module has been compiled AoT
        if (moduleOrFactory instanceof NgModuleFactory) {
            console.log('Already AoT?');
            resolve(moduleOrFactory);
            return;
        }
        else {
            var moduleFactory = factoryCacheMap.get(moduleOrFactory);
            // If module factory is cached
            if (moduleFactory) {
                console.log('\n\n\n WE FOUND ONE!! USE IT!!\n\n\n');
                resolve(moduleFactory);
                return;
            }
            // Compile the module and cache it
            compiler.compileModuleAsync(moduleOrFactory)
                .then(function (factory) {
                console.log('\n\n\n\n MAP THIS THING!!!!\n\n\n ');
                factoryCacheMap.set(moduleOrFactory, factory);
                resolve(factory);
            }, (function (err) {
                reject(err);
            }));
        }
    });
}
