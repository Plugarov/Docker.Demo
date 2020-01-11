## Docker basics and notes

1. Setup and run Docker
2. Run multiple Web API's
3. Setup MS SQL
4. Setup message broker

#### Ubuntu on Windows 
https://www.youtube.com/watch?v=JgurvumloHk  
VirtualBox www.virtualbox.org  

Commands
Uninstall docker  
dpkg -l | grep -i docker  
sudo apt-get purge docker-ce  
sudo rm -rf /var/lib/docker  

#### Docker commands
docker build -t simpleapi (csproj name) .  
docker run -d -p 1236:80 simpleapi (run in background)  
docker ps (containers)  
docker ps -a (all)  
docker images  
docker rm (container)  
docker rmi (image)  

#### Images
MS SQL https://hub.docker.com/_/microsoft-mssql-server

### References
- Setup on IIS using VSCode https://dotnetplaybook.com/deploy-a-net-core-api-with-docker/
- Docker for windows https://docs.docker.com/docker-for-windows/
- Docker commands https://docs.docker.com/engine/reference/commandline/run/
- Docker Hub https://hub.docker.com/ 
