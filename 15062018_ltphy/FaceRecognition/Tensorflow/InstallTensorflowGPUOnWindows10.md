# How to Install Tensorflow on Windows with GPU

## 1. Install Tensorflow-GPU 1.5
1. Install [Anaconda 3.5 or 3.6](https://www.anaconda.com/)
2. [Cuda tool kit(ver 9.0)](https://developer.nvidia.com/cuda-downloads?target_os=Windows&target_arch=x86_64&target_version=10&target_type=exelocal)
3. [CuDNN ver v7 FOR V9 CUDA](https://developer.nvidia.com/rdp/cudnn-archive) v7 for v9 CUDA

## 2. Install pip
 - Install [git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) 
## 3. Edit system virtual environment for CUDA:
- bin, libnvvp, libx64
- Put Cuda folder in CUDNN to C:\ and add the the C:\cuda\bin to sytem variable
## 4. update GPU Driver:
- [Link](http://www.nvidia.com/download/driverResults.aspx/135277/en-us) to upgrade latest drivers
## 5. Download full [Tensorflow object detection](https://github.com/tensorflow/models)
- Download [Faster-RCNN-Inception-V2](http://download.tensorflow.org/models/object_detection/faster_rcnn_inception_v2_coco_2018_01_28.tar.gz)
and put it to models\research\object_detection folder (as a checkpoint)
- Install tensorflow:
```
pip install --ignore-installed --upgrade tensorflow-gpu
```
or install anaconda virtual env: 
```
conda create -n tensorflow pip python=3.6
```
- Activate virtual environment "Tensorflow" (use Anaconda Prompt)/ or can go directly to Anaconda Navigator
```
pip install --ignore-installed --upgrade tensorflow-gpu
```
- Install neccesarry libraries:
```
conda install -c anaconda protobuf
pip install pillow
pip install lxml
pip install Cython
pip install jupyter
pip install matplotlib
pip install pandas
pip install opencv-python
```
## 6. Configure PYTHONPATH enviroment 
```
(Tensorflow) C:\> set PYTHONPATH=D:\Project\models;D:\Project\models\research;D:\Project\models\research\slim
```
Note: Remember to config Python path environment everytime you reopen your command prompt in Tensorflow.

## 7. Compile Protobufs and run setup.py
```
cd to \models\research folder
protoc --python_out=. .\object_detection\protos\anchor_generator.proto .\object_detection\protos\argmax_matcher.proto .\object_detection\protos\bipartite_matcher.proto .\object_detection\protos\box_coder.proto .\object_detection\protos\box_predictor.proto .\object_detection\protos\eval.proto .\object_detection\protos\faster_rcnn.proto .\object_detection\protos\faster_rcnn_box_coder.proto .\object_detection\protos\grid_anchor_generator.proto .\object_detection\protos\hyperparams.proto .\object_detection\protos\image_resizer.proto .\object_detection\protos\input_reader.proto .\object_detection\protos\losses.proto .\object_detection\protos\matcher.proto .\object_detection\protos\mean_stddev_box_coder.proto .\object_detection\protos\model.proto .\object_detection\protos\optimizer.proto .\object_detection\protos\pipeline.proto .\object_detection\protos\post_processing.proto .\object_detection\protos\preprocessor.proto .\object_detection\protos\region_similarity_calculator.proto .\object_detection\protos\square_box_coder.proto .\object_detection\protos\ssd.proto .\object_detection\protos\ssd_anchor_generator.proto .\object_detection\protos\string_int_label_map.proto .\object_detection\protos\train.proto .\object_detection\protos\keypoint_box_coder.proto .\object_detection\protos\multiscale_anchor_generator.proto .\object_detection\protos\graph_rewriter.proto

python setup.py build
python setup.py install
```

Check whether it works by running: in ../object_detection 
```
jupyter notebook object_detection_tutorial.ipynb
```
### Step to setup Training Dataset
 1. Collect images and put 20% to test and 80% to train folder.  
 2. Label the picture by using LabelImg  
Convert xml by using python xml_to_csv.py  
 3. Open generate_tfrecord.py file and edit def class_text_to_int
 4. Generate train and test record in the folder \object_detection
```
python generate_tfrecord.py --csv_input=images\train_labels.csv --image_dir=images\train --output_path=train.record
python generate_tfrecord.py --csv_input=images\test_labels.csv --image_dir=images\test --output_path=test.record
```
 5. Create a labelmap.pbtxt 
 - In training folder, edit the id and name of object suitably.  
 6. Config training  

Look into: C:\tensorflow1\models\research\object_detection\samples\configs:

Use the faster_rcnn_inception_v2_pets.config as config file copy to the training folder

 7. Everytime the tensorflow reset must:  
```
set PYTHONPATH=D:\Project\models;D:\Project\models\research;D:\Project\models\research\slim
```

- Switch to tf.train.create_global_step
- In the file learning_schedules.py change range() to list(range())  
**ISSUE**:  
https://github.com/tensorflow/models/issues/3705#issuecomment-375563179

 8. Training:
```
python train.py --logtostderr --train_dir=training/ --pipeline_config_path=training/ssd_mobilenet_v1_coco.config
```

 9. Export inference graph  
```
python export_inference_graph.py --input_type image_tensor --pipeline_config_path training/faster_rcnn_inception_v2_pets.config --trained_checkpoint_prefix training/model.ckpt-189769 --output_directory inference_graph
python export_inference_graph.py --input_type image_tensor --pipeline_config_path training/ssd_mobilenet_v1_coco.config --trained_checkpoint_prefix training/model.ckpt-61297 --output_directory inference_graph
```
Choose the highest check point to train your model.   
**Note**:   
- Install opencv2 for resizer.py