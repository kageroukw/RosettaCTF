// This file is part of RosettaCTF project.
//
// Copyright 2020 Emzi0767
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

import { Component, OnInit, ViewChild, ViewContainerRef, ComponentFactoryResolver, ComponentRef, OnDestroy, Input } from "@angular/core";
import { Router, ResolveEnd } from "@angular/router";

import { INavbarData } from "../data/navbar";
import { Observable } from "rxjs";
import { IApiEventConfiguration } from "../data/api";
import { ConfigurationProviderService } from "../services/configuration-provider.service";
import { ISession } from "../data/session";
import { SessionProviderService } from "../services/session-provider.service";

@Component({
    selector: "app-navbar",
    templateUrl: "./navbar.component.html",
    styleUrls: ["./navbar.component.less"]
})
export class NavbarComponent implements OnInit, OnDestroy {

    @ViewChild("buttonContainer", { read: ViewContainerRef, static: true })
    container: ViewContainerRef;
    private component: ComponentRef<any>;

    configuration$: Observable<IApiEventConfiguration>;

    session$: Observable<ISession>;

    constructor(private router: Router,
                private resolver: ComponentFactoryResolver,
                private configurationProvider: ConfigurationProviderService,
                private sessionProvider: SessionProviderService) {
        this.configuration$ = this.configurationProvider.configurationChange;
        this.session$ = this.sessionProvider.sessionChange;
    }

    ngOnInit(): void {
        this.router.events.subscribe(x => {
            if (!(x instanceof ResolveEnd)) {
                return;
            }
            const data = x.state.root.children[0].data as INavbarData;

            this.container.clear();
            if (!!this.component) {
                this.component.destroy();
                this.component = null;
            }

            if (!!data.buttons) {
                const factory = this.resolver.resolveComponentFactory(data.buttons);
                this.component = this.container.createComponent(factory);
            }
        });
    }

    ngOnDestroy(): void {
        this.component.destroy();
    }
}
