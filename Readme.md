# Kindle Mate Backlog Monitor

This is my private project which allow me to dump some statistics from a KindleMate program's database.

It's a quick & dirty solution, even if you landed here somehow, you certainly shouldn't care about this project ;)

# How to run?

## First run
```
docker run --name kindlemate -v "/datadrive/ResilioStorage/resilio-inbox/KindleMate:/KindleMate:rw" taurit/kindlematebacklogmonitor:latest
```

## Seeing logs
```
docker logs kindlemate
```

## Updating the image after code change

1. Make sure new image has been built successfully on [Docker Hub](https://cloud.docker.com/u/taurit/repository/docker/taurit/kindlematebacklogmonitor)
2. Go with the following commands
```
docker stop kindlemate
docker rm kindlemate
docker pull taurit/kindlematebacklogmonitor:latest
```
3. Repeat the "first run" part (run = create & start container) - now a new vesion will be used
