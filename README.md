## Docker basics and notes

1. Setup and run Docker
2. Run multiple Web API's
3. Setup Microsoft SQL Server  
4. Setup message broker

#### Ubuntu
https://www.youtube.com/watch?v=JgurvumloHk  
VirtualBox www.virtualbox.org  

##### Commands  
Uninstall  
dpkg -l | grep -i docker  
sudo apt-get purge docker-ce  
sudo rm -rf /var/lib/docker  



#### Docker 
##### Commands  

Start  
service --status-all  
sudo service docker start  

Login  
sudo docker login  
sudo usermod -aG docker $USER (access without sudo)  
sudo -i

Manage  
docker build -t simpleapi (csproj name) .  
docker run -d -p 1236:80 simpleapi (run in background)  
docker ps (containers)  
docker ps -a (all)  
docker images  
docker rm (container)  
docker rmi (image)  

Publish  
docker tag docker201 iankesh/docker201  
docker push iankesh/docker201  

##### Images
MS SQL https://hub.docker.com/_/microsoft-mssql-server

### References
- Setup on IIS using VSCode https://dotnetplaybook.com/deploy-a-net-core-api-with-docker/
- Docker for windows https://docs.docker.com/docker-for-windows/
- Docker commands https://docs.docker.com/engine/reference/commandline/run/
- Docker Hub https://hub.docker.com/ 
