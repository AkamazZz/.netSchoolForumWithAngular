import { Component } from '@angular/core';
import { trigger, state, transition, animate, keyframes, style } from '@angular/animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
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
  ]
})
export class AppComponent {
  title = 'hierarchy';

}
