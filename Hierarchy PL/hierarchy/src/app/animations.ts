import { Component } from '@angular/core';
import { transition, trigger, useAnimation,state,style,animate,keyframes, animation } from '@angular/animations';
export const FadeInOut= 
    trigger("flyInOut", [
      state("in", style({ transform: "translateX(0)" })),
      transition("void => *", [
        animate(
          300,
          keyframes([
            style({ opacity: 0}),
            style({ opacity: 1}),
          ])
        )
      ]),
      transition("* => void", [
        animate(
          300,
          keyframes([
            style({ opacity: 1}),
            style({ opacity: 0}),
          ])
        )
      ])
    ])
   
