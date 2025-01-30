Create Image
docker build -t vaxidrez-net-image:v1.0 .


Install docker container
docker run -d -p 80:5000 --name backend-net-app vaxidrez-net-image:v1.0