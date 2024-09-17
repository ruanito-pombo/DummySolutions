# MySql Server Docker Setup

## Pull MySql's latest docker image:
```powershell
docker pull mysql
```

## MySql Server Configurations:
* (Optional) Change the "MYSQL_ROOT_PASSWORD" parameter below or leave as it is;

## Start MySql Server (local):
```bash
docker run -d --restart=unless-stopped --network=docker-network --name=mysql-server -e "MYSQL_ROOT_PASSWORD=!MySqlRoot1234" -e "MYSQL_ROOT_HOST=%" -p 3306:3306 mysql:latest
```

## Database Configurations:
* Connect to your MySql Server
```powershell
docker exec -it mysql-server mysql -uroot -p
```

* Execute these commands in order
```
CREATE DATABASE `DbFull`;
EXIT;
```
---