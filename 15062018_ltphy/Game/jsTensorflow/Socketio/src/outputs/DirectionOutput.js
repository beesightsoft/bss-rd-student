var io = require('socket.io-client');
var socket = io.connect('http://localhost:3000', {reconnect: true});

// Add a connect listener
socket.on('connect', function (socket) {
    console.log('Connected!');
});
socket.on('disconnect',function(){
    console.log('user disconnected'); 
  });
class DirectionOutput {

    constructor() {
        this.id = 'DirectionOutput';
        /*this.script = document.createElement('script');
        this.script.src = '/socket.io/socket.io.js';
        document.getElementsByTagName('body')[0].appendChild(this.script);
        this.script = document.createElement('script');
        this.script.src = 'https://code.jquery.com/jquery-1.11.1.js';
        document.getElementsByTagName('body')[0].appendChild(this.script);
        */
        this.checkArray = [0,0,0];
        this.valid = false;
        this.currentIndex = null;

        this.element = document.createElement('div');
        this.element.classList.add('output__container');
        this.element.classList.add('output__container--speech');
        //this.socket = io();
        this.defaultMessages = [
        'left',
        'stand',
        'right'
        ];
        //global
        this.classNames = GLOBALS.classNames;
        this.colors = GLOBALS.colors;
        this.numClasses = GLOBALS.numClasses;

        this.offScreen = document.createElement('div');
        this.offScreen.classList.add('output__speech'); 


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


    checkValid(array, len) //check whether all classes has already been trained
    {

        for(let i =0;i<len;i++)
        {
            if(array[i]== 0)
            {
                return false;
            }
        }
        return true;
    }

    //var socket = io();
    //the function in learning class will call this function

    trigger(index){
        if (!GLOBALS.clearing) {
            if (this.currentIndex !== index) {
             
                this.currentIndex = index; //to get the correct index
                //this.count++;
                //remove border for the old index
                this.checkArray[this.currentIndex]++;
                if(this.valid === false)
                {
                    if(this.checkValid(this.checkArray,this.numClasses))
                    {
                        this.valid = true;
                    }
                }
               if (this.currentBorder && this.currentClassName) {
                    this.currentBorder.classList.remove(`output__speech-input--${this.currentClassName}-selected`);
                    
                }

                //add border for the new higher confidence class
                let border = this.inputClasses[index].input;
                let id = this.classNames[index];

                this.currentClassName = id;
                this.currentBorder = border;
                this.currentBorder.classList.add(`output__speech-input--${this.currentClassName}-selected`);
                if(this.valid===true)//if all classes has already trained start print messages
                {
                    console.log(this.defaultMessages[index]);
                    var value = this.defaultMessages[index];
                   /* var io = require('socket.io-client');
                    var socket = io.connect('http://localhost:3000', {reconnect: true});

// Add a connect listener
                    socket.on('connect', function (socket) {
                    console.log('Connected!');
                    });*/
                    //var socket = io();
                    socket.emit('chat', value);//this.defaultMessages[index]);
                       
                      
                }
               
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
//import TextToSpeech from './speech/TextToSpeech.js';
import GLOBALS from './../config.js';
//import io from ''
export default DirectionOutput;