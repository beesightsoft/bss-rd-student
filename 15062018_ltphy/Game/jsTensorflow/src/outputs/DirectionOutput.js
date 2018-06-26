class DirectionOutput {
    constructor() {
        this.id = 'DirectionOutput';

        this.count = 0;
        this.currentSound = null;
        this.currentIcon = null;
        this.currentIndex = null;
       this.textToSpeech = new TextToSpeech();
        this.element = document.createElement('div');
        this.element.classList.add('output__container');
        this.element.classList.add('output__container--speech');
        
        this.defaultMessages = [
        'Left',
        'Stand',
        'Right'
        ];
        //global
        this.classNames = GLOBALS.classNames;
        this.colors = GLOBALS.colors;
        this.numClasses = GLOBALS.numClasses;

        this.offScreen = document.createElement('div');
        this.offScreen.classList.add('output__speech'); 

        let options = {};

        this.inputClasses = [];
        for (let index = 0; index < this.numClasses; index += 1) {
            let id = this.classNames[index];
            let inputClass = document.createElement('div');

            let message = this.defaultMessages[index];
            inputClass.defaultMessage = message;
            inputClass.message = message;
            inputClass.classList.add('output__speech-class');
            inputClass.classList.add(`output__speech-class--${id}`);

            let input = document.createElement('p');
            input.classId = id;
            input.classList.add('output__speech-input');
            input.classList.add(`output__speech-input--${id}`);
            input.setAttribute('maxlength', 25);
            input.innerHTML = this.defaultMessages[index];
            
            inputClass.appendChild(input);

            inputClass.input = input;

            this.inputClasses[index] = inputClass;
            this.element.appendChild(inputClass); //assign instantiated input class to inputClasses
        }
        this.buildCanvas();
    }



    filterResults() {
        let phrase = this.searchInput.value;
        if (phrase.length === 0) {
            phrase = 'Hello';
        }
        this.ttsItem.children[1].value = `"${phrase}"`;
        this.ttsItem.value = `"${phrase}"`;
    }



    //the function in learning class will call this function 

    trigger(index){
        if (!GLOBALS.clearing) {
            if (this.currentIndex !== index) {
             
                this.currentIndex = index; //to get the correct index
                this.count++;
                //remove border for the old index
               if (this.currentBorder && this.currentClassName) {
                    this.currentBorder.classList.remove(`output__speech-input--${this.currentClassName}-selected`);
                    
                }

                //add border for the new higher confidence class
                let border = this.inputClasses[index].input;
                let id = this.classNames[index];

                this.currentClassName = id;
                this.currentBorder = border;
                this.currentBorder.classList.add(`output__speech-input--${this.currentClassName}-selected`);
                console.log(this.defaultMessages[index]);
                
            }
        }
        if (GLOBALS.clearing) {
            if (this.currentBorder && this.currentClassName) {
                this.currentBorder.classList.remove(`output__speech-input--${this.currentClassName}-selected`);
               
            }
           
        }

    
    }



    buildCanvas() {
        this.canvas = document.createElement('canvas');
        this.canvas.style.display = 'none';
        this.context = this.canvas.getContext('2d');
        this.canvas.width = 340;
        this.canvas.height = 260;
        this.element.appendChild(this.canvas);
    }



}
import TextToSpeech from './speech/TextToSpeech.js';
import GLOBALS from './../config.js';

export default DirectionOutput;