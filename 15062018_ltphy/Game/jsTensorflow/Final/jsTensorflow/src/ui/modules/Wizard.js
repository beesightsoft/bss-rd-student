// Copyright 2017 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

/* eslint-disable consistent-return, callback-return, no-case-declarations */
import GLOBALS from './../../config.js';
import TweenLite from 'gsap';

class Wizard {
    constructor() {

        

this.wizardRunning = false;
this.percentage = 0;
this.duration = 0;
this.baseTime = 0;
this.currentTime = 0;

this.stopTime = 0;
this.bar = document.querySelector('#wizard');
this.machine = document.querySelector('.machine');

this.classTrainedEvent = this.classTrained.bind(this);

this.numTriggered = 0;
this.lastClassTriggered = null;

this.activateWebcamButton = document.getElementById('input__media__activate');
this.activateWebcamButton.style.display = 'none';
if (this.activateWebcamButton) {
  this.activateWebcamButton.addEventListener('click', () => {
    location.reload();
});
}


this.resizeEvent = this.size.bind(this);
this.scrollEvent = this.scroll.bind(this);
window.addEventListener('resize', this.resizeEvent);
window.addEventListener('scroll', this.scrollEvent);


this.resizeEvent();
this.scrollEvent();
}

stickBar() {
    this.bar.classList.add('wizard--fixed');
    this.stickyBar = true;
}

unstickBar() {
    this.bar.classList.remove('wizard--fixed');
    this.stickyBar = false;
}

size() {

    if (this.machine.offsetHeight + this.bar.offsetHeight - window.pageYOffset > window.innerHeight) {
        this.stickBar();
    }else if (this.stickyBar) {
        this.unstickBar();
    }
}

scroll() {
    if (this.machine.offsetHeight + this.bar.offsetHeight - window.pageYOffset <= window.innerHeight) {
        this.unstickBar();
    }else {
        this.stickBar();
    }
}


classTriggered(event) {
    let id = event.detail.id;

    if (id !== this.lastClassTriggered) {
        this.lastClassTriggered = id;
        this.numTriggered += 1;
    }

    if (this.numTriggered > 4 && !this.triggerTimer) {
        GLOBALS.outputSection.stopWizardMode();
        this.triggerTimer = setTimeout(() => {
        }, 1500);
    }
}

classTrained(event) {
    let id = event.detail.id;
    let numSamples = event.detail.numSamples;

    if (numSamples < 30) {
    }

    if (id === 'green' && numSamples >= 30) {
        GLOBALS.learningSection.dehighlightClass(0);
        GLOBALS.inputSection.hideGif(0);
        window.removeEventListener('class-trained', this.classTrainedEvent);
    }

    if (id === 'purple' && numSamples >= 30) {
        GLOBALS.learningSection.dehighlightClass(1);
        GLOBALS.inputSection.hideGif(1);
        window.removeEventListener('class-trained', this.classTrainedEvent);
    }
}

toggleSound(event) {
    event.preventDefault();
    if (this.muted) {
        this.unmute();
    }else {
        this.mute();
    }
}

ended() {
    this.playing = false;
    this.stopAudioTimer();

    if (this.currentIndex === 0) {
        let that = this;

        if (localStorage.getItem('webcam_status') === null) {
            //this.play(1);
            this.webcamEvent = this.webcamStatus.bind(this);
            window.addEventListener('webcam-status', this.webcamEvent);
        }else if (localStorage.getItem('webcam_status') === 'granted') {
            GLOBALS.camInput.start();
            ///this.play(2);
        }else if (localStorage.getItem('webcam_status') === 'denied') {
            //this.play(7);

        }
    }

}

clear() {
   // this.textContainer.textContent = '';
}

webcamStatus(event) {
    let that = this;
    if (event.detail.granted === true) {
        localStorage.setItem('webcam_status', 'granted');
        //this.play(2);
        window.removeEventListener('webcam-status', this.webcamEvent);
    }else {
        localStorage.setItem('webcam_status', 'denied');
       // this.play(7);
    }
}

start() {
    let that = this;
    this.wizardRunning = true;
    //this.soundButton.style.display = 'block';
    //this.play(0);
    //this.startAudioTimer();
    GLOBALS.launchScreen.destroy();
    console.log("so");
    this.skip();
    //gtag('event', 'wizard_start');        
}

startCamera() {
    GLOBALS.camInput.start();
}

skip() {
    /*
   if (this.wizardRunning) {
        TweenLite.to(this.wizardWrapper, 0.3, {
            height: 0,
            onComplete: () => {
                this.wizardWrapper.style.display = 'none';
            }
        });
    }else {
        this.wizardWrapper.style.display = 'none';
    }
*/
    this.clear();
    //this.skipButton.style.display = 'none';
    //this.soundButton.style.display = 'none';
    window.removeEventListener('class-trained', this.classTrainedEvent);
    setTimeout(() => {
        GLOBALS.camInput.start();
    }, 500);
    GLOBALS.inputSection.enable();
    GLOBALS.inputSection.hideGif(0);
    GLOBALS.inputSection.hideGif(1);
    GLOBALS.inputSection.hideGif(2);
    GLOBALS.inputSection.hideGif(3);
    GLOBALS.inputSection.undim();
    GLOBALS.learningSection.dehighlight();
    GLOBALS.learningSection.dehighlightClass(0);
    GLOBALS.learningSection.dehighlightClass(1);
    GLOBALS.learningSection.dehighlightClass(2);
    GLOBALS.learningSection.enable();
    GLOBALS.learningSection.enableClass(0);
    GLOBALS.learningSection.enableClass(1);
    GLOBALS.learningSection.enableClass(2);
    GLOBALS.learningSection.undim();
    GLOBALS.outputSection.dehighlight();
    GLOBALS.outputSection.enable();
    GLOBALS.outputSection.undim();

    window.removeEventListener('resize', this.resizeEvent);
    window.removeEventListener('scroll', this.scrollEvent);
}

}

export default Wizard;
/* eslint-enable consistent-return, callback-return, no-case-declarations */