# Ecommerce Open Source Project
## this is my first project is Asp.Net
### it is Ecommerce With Some Feature That I Will Mention At this readme File

# technologies that i Used is 
### Docker
### Kubernetes
### ElasticSearch
### Design Pattern
### Mediator
### Aws S3



# Requirement

### if you want to use AWS To Upload your image you should add the following statement to **`application.json`**
```

  "S3": {

    "AccessKey": "your access key",
    "SecretKey": "your secret key",
    "BucketName": "your bucket name",
    "url": "https://ecommerceasp.s3.amazonaws.com"


  }
```
### you should add your application host in application.json like this:
```
  "host": "https://localhost:8070"

```
### you should put in appsetting.json file

```
  "EmailConfiguration": {
    "From": "your email",
    "SmtpServer": "smtp.gmail.com",
    "Port": 587,
    "Username": "your email",
    "Password": "your password"
  },
```


###### do not forget that your bucket publiclly read access only   

### to Use This Project You Just Need  Docker and you should run the below command
```
cd Kunernetes/Database .

kubectl apply -f Database-pvc.yml .

kubectl apply -f databaseDeployment.yml .

kubectl apply -f DatabaseService.yml .

kubectl apply -f database-service-access.yml .

cd ../Authentication

kubectl apply -f AuthenticationDeployment.yml .
kubectl apply -f AuthenticationService.yml .




```


### you can see your kibana for elasticsearch by this  url
```
http://localhost:8070

```

### To See Your APi You Can Check the Following [link](http://localhost:8070/swagger/index.html)
