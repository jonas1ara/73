#!/bin/bash

# Instalar dependencias en una distribucion basada en Debian

 

sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-7.0 &&\
    sudo apt install build-essential -y

