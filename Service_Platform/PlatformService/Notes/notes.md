# Notes from the course on Microservices

## MS features
1. Small (small teams)
2. Responsible for doing one thing well
3. Organisationally aligned (Sales, product, marketing,...) 
4. Form part of the (distributed) whole
5. Self contained - Autonomous

## Problems with monolith
1. Very difficult to change
2. Change cycles are months in duration
3. Massive amount of testing, usually manual
4. Difficult to scale
5. Locked in from technology term and intellectual property


## Benefits of MS
1. Easier to change and deploy (small & decoupled)
2. Can be built using different technologies
3. Increased organizational ownership & alignment
4. Resilient: 1 service can break, but the others will continue to run
5. Scalable: You can scale out only the services you need to
6. Built to be highly replaceable / swappable

## Disadvantages of Microservices
1. Are difficult to implement a large number of MS (no way around it)
2. Can result in Analysis paralysis! You need to understand the business domain
3. Need strong domain knowledge
4. Distributed, there is always a chance for the network to fail or slow down

## Benefits of Monolith
1. Simpler to implement
2. Can use CI/CD, daily deploys, small changes,...
3. Building a monolith allows you to familiarise yourself with the domain
4. You can still have 2-3 big services. A hybrid model. 
5. Not as reliant on network as MS



# Services we are going to build
Platform service:
        Functions as an asset register and Tracks all the platforms / systems
        in the company. It is built by the infrastructure team. 

It is used by:
1. Infrastructure team
2. Technical support team
3. Engineering
4. Accounting
5. Procurement

Command Service:
It acts as s function as a repository of command line arguments for given platforms
It aids in the automation support process
Built by the technical support team

It is used by:
1. Tech support
2. Infrastructure team
3. Engineering
 
## Solution Architecting
The overall design is about decoupling services from each other. Services communicate
through a message bus. They raise events where the other services are subscribed to.
We are adding GRPC in this design as it is a popular mechanism in MS. In this particular 
case, the GRPC from Command Service makes calls to Platform service to get services 
available.

![solution_architect.png](images%2Fsolution_architect.png)
## Platform Service Architecture
This is the Platform architecture design

![Platform_service_arch.png](images%2FPlatform_service_arch.png)


## Command Service Architecture

![Screenshot 2023-03-06 at 21.12.18.png](..%2F..%2F..%2F..%2F..%2F..%2F..%2Fvar%2Ffolders%2Fk3%2F5v1dxfv12z37py13v538m66w0000gn%2FT%2FTemporaryItems%2FNSIRD_screencaptureui_9t9x0M%2FScreenshot%202023-03-06%20at%2021.12.18.png)

# Models
In this application, we are dealing with two types of models.
Models in the Models folder refer to internal models while DTO (Data Transfer Objects) refer to external objects.

# Deploying the app to Docker
In .Net 7, we don't need to maintain a docker file anymore. To add our .Net 7 solution 
to Docker, what we need to do is to add this package to our solution first:

`dotnet add package Microsoft.NET.Build.Containers`

Then, we need to type the following message in command line:

`dotnet publish --os linux --arch arm64 -p:PublishProfile=DefaultContainer -p:ContainerImageName=[Name your container image for the project]`


## What are we building now?
We are going to deploy our solutions to K8s. In K8 we will have multiple pods.
Each Pod will host a service. 
![end_design_1.png](images%2Fend_design_1.png)

Node port is to test services in the pods to make sure they are working correctly.
In production, we won't have node ports.
Ingress Nginx acts as the Load Balancer where the ouside world has to hit to send requests to the services in the pods

Ultimately, our final design will be like this:

![end_design_2.png](images%2Fend_design_2.png)

