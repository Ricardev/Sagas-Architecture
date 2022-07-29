# Sagas-Architecture

A project to show how a sagas architecture works, using Envoy as an Api Gateway to connect your microservices and Steeltoe as a Load Balancer.
Basically, the principle is: if one transaction goes wrong in a transaction chain, you want to rollback every prior transaction.
Doing this, you won't have a corrupted database.
