import { Injectable, ErrorHandler, Injector } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private injector: Injector) {
      
  }

  public handleError(error: any) {
    console.error(error.name + ": " + error.message);
  }
}