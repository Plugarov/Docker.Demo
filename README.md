## Docker & RabbitMQ basics and notes

1. Setup and run Docker
2. Run multiple Web API's
3. Setup Microsoft SQL Server  
4. Setup message broker

#### Ubuntu
##### Commands  
Uninstall  
dpkg -l | grep -i docker  
sudo apt-get purge docker-ce  
sudo rm -rf /var/lib/docker  



#### Docker 
##### Commands  

Start  
service --status-all  
service docker start  

Login  
docker login  
usermod -aG docker $USER (access without sudo)  

Manage  
docker build -t simpleapi (csproj name) .  
docker run -d -p 1236:80 simpleapi (run in background)  
docker ps (containers)  
docker ps -a (all)  
docker images  
docker rm (container)  
docker rmi (image)  
docker rmi $(docker images -f "dangling=true" -q)  

Publish  
docker tag docker201 iankesh/docker201  
docker push iankesh/docker201  

#### RabbitMQ  
##### Commands  
docker run -d --hostname my-rabbit --name Rabbit -e RABBITMQ_DEFAULT_USER=root -e RABBITMQ_DEFAULT_PASS=root -p 15672:15672 -p 5672:5672 rabbitmq:3-management

##### Images
MS SQL https://hub.docker.com/_/microsoft-mssql-server

### References
- Setup on IIS using VSCode https://dotnetplaybook.com/deploy-a-net-core-api-with-docker/
- Docker for windows https://docs.docker.com/docker-for-windows/
- Docker commands https://docs.docker.com/engine/reference/commandline/run/
- Docker Hub https://hub.docker.com/ 
- RabbitMQ https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html  
- RabbitMQ https://registry.hub.docker.com/_/rabbitmq/  
