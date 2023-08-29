# Ecommerce Open Source Project
## this is my first project is Asp.Net
### it is Ecommerce With Some Feature That I Will Mention At this readme File

# Requirement

### if you want to use AWS To Upload your image you should add the following statement to **`application.json`**
```

  "S3": {

    "AccessKey": "your access key",
    "SecretKey": "your secret key",
    "BucketName": "your bucket name"

  }
```
###### do not forget that your bucket publiclly read access only   
### to Use This Project You Just Need  Docker and you should run the below command
```
docker-compose up --build
```


### To See Your APi You Can Check the Following [link](http://localhost:8080/swagger/index.html)
##### to Customize Port you can Edit By Open **`docker-compose`** And Change Port to  - "YourPort:80" 
