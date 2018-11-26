﻿import { Directive, OnInit, ElementRef } from '@angular/core';

@Directive({
    selector: '[Autofocus]'
})

export class AutofocusDirective implements OnInit {

    constructor(private elementRef: ElementRef) { };

    ngOnInit(): void {
        debugger
        this.elementRef.nativeElement.focus();
    }
}