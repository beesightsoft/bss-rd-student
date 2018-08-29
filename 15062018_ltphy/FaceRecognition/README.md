# Face Recognition using Tensorflow Object Detection API and Face Recognition library.

## Tensorflow
 The Face Recognition using Tensorflow is implemented by following the instruction from [this](https://github.com/EdjeElectronics/TensorFlow-Object-Detection-API-Tutorial-Train-Multiple-Objects-Windows-10)

### Pre-trained Tensorflow models
There are several pre-trained classifiers supplied by Tensorflow which can be downloaded [here](https://github.com/tensorflow/models/blob/master/research/object_detection/g3doc/detection_model_zoo.md).
However, we choose SSD_MobileNet_V1, since it offers a faster detection which can be deployed on Android.
### Result
- After nearly 200,000 training steps, we can not regconize any faces by using 500 images with 2 classes. Our data samples are caught by using Samsung Galaxy A6 16mp.
- So, be careful to use your own data samples for face recognition problems.   

 ## Face Recognition with dlib
 The implementation of this project is followed from the instruction of [this](https://github.com/ageitgey/face_recognition#face-recognition)
 ### Installation
 Environment: Windows 10
 ``` 
 pip install face_recognition
 ```
 By using the above command, it will download all neccessary libraries which includes face recognition as well as dlib.
 
 ### Prepare Dataset
 - Catching several pictures of people you want to recognize faces or collecting from internet (around 3-5 should be enough but the more the better.)
 - Put your caught pictures to the folders which the name of the folder is the name of each class and put those folders into 'train' folder.
 - Put your test picture in 'test' folder.
 ### Running Classifier
 The face_recognition_knn.py is got from the folder example of [this](https://github.com/ageitgey/face_recognition/tree/master/examples). However, it is adjusted to suit my case.
 ```
 python face_recognition_knn.py
 ```
 
 After first try, we can only recognize only 1 samples. Therefore, we change the filter's of each image to sauna with the intensity of 50.
 ### Result
![result4](https://user-images.githubusercontent.com/32784614/43309256-7fb7182c-91ae-11e8-9004-1dcb76a33f71.jpg)

 <b>RECOMMEND</b>: If the face regconition can not extract any face encodings. Try to change the image's filter with different intensities.<br/>
 <b>WARNING</b>: The effects are only applicable with our data samples. We do not guarantee that it will work with other data samples.
 
### Dataset
- The data samples are collected from humans in BeesightSoft's Android department.<br/>
- Just use them as data samples. Please <b> DO NOT USE </b> them for any other purposes that may affect their lives.
 