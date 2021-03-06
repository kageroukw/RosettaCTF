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

import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, ParamMap } from "@angular/router";

import { EventDispatcherService } from "../../services/event-dispatcher.service";
import { RosettaApiService } from "../../services/rosetta-api.service";
import { ErrorDialogComponent } from "../../dialog/error-dialog/error-dialog.component";
import { SessionProviderService } from "../../services/session-provider.service";
import { waitOpen, waitClose } from "../../common/waits";

@Component({
    selector: "app-callback",
    templateUrl: "./callback.component.html",
    styleUrls: ["./callback.component.less"]
})
export class CallbackComponent implements OnInit {

    constructor(private eventDispatcher: EventDispatcherService,
                private api: RosettaApiService,
                private router: Router,
                private currentRoute: ActivatedRoute,
                private sessionProvider: SessionProviderService) { }

    ngOnInit(): void {
        const args = this.currentRoute.snapshot.queryParamMap;
        if (args.has("error") || !args.has("code") || !args.has("state")) {
            if (args.has("error")) {
                this.eventDispatcher.emit("dialog", { componentType: ErrorDialogComponent, defaults: { message: "You refused to authorized the application. You need to allow access for login to work.", reason: null } });
            } else {
                this.eventDispatcher.emit("error", { message: "Login failed. Please try again.", reason: null });
            }

            this.router.navigate(["/"]);
            return;
        }

        this.completeInit(args);
    }

    async completeInit(args: ParamMap): Promise<void> {
        await this.sessionProvider.isAuthenticated();
        waitOpen(this.eventDispatcher);

        const x = await this.api.completeOAuthLogin(args.get("code"), args.get("state"), document.referrer);
        if (!x.isSuccess) {
            this.eventDispatcher.emit("error", { message: "Login failed. Please try again.", reason: x.error });
            this.router.navigate(["/"]);
            return;
        }

        this.sessionProvider.updateSession(x.result);
        await this.api.refreshXsrf();
        waitClose(this.eventDispatcher);
        this.router.navigate(["/"]);
    }

}
