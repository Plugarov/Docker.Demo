## Docker basics and notes

1. Setup and run Docker
2. Run multiple Web API's
3. Setup MS SQL


#### Docker commands
docker build -t simpleapi (csproj name) .  
docker run -d -p 1236:80 simpleapi (run in background)  
docker ps (containers)  
docker ps -a (all)  
docker images  
docker rm (container)  
docker rmi (image)  

### References
- Setup on IIS using VSCode https://dotnetplaybook.com/deploy-a-net-core-api-with-docker/
- Docker commands https://docs.docker.com/engine/reference/commandline/run/
- Docker Hub https://hub.docker.com/ 
- MS SQL https://hub.docker.com/_/microsoft-mssql-server
