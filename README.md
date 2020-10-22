# MicroServiceWithRabbitMQ

#STEP 0:
---------

Check Erlang compatability with RabbitMQ -> https://www.rabbitmq.com/which-erlang.html

** Installtion

Download & Install Erlang -> https://www.erlang.org/downloads

Download & Install Rabbit_MQ -> https://www.rabbitmq.com/download.html


Set Environment variable
---------------------------
RABBITMQ_BASE c:\RabbitMQ Server

ERLANG_HOME C:\Program Files\erl10.7


Config MQ Server
-----------------
stop RabbitMq : rabbitmq-service.bat stop

Enable management : rabbitmq-plugins.bat enable rabbitmq_management

Reinstall server : rabbitmq-service.bat install

Start Server : rabbitmq-service.bat start

Start App : rabbitmqctl.bat start_app

Open Brower : http://localhost:15672 user guest / guest


Add new User
--------------

List users : rabbitmqctl.bat list_users

Add new user : rabbitmqctl.bat add_user user1 pass1

Give administrator privileges : rabbitmqctl.bat set_user_tags user1

#STEP 1:
---------

See branch "Step1" -> https://github.com/matijakatadzic/MicroServiceWithRabbitMQ/commit/b01e4b2d4b8d49abf93d883bfb399fd96d6d1fc7

Add Consumer(MicroService 1) and Producer(MicroService 2) new empty project


#STEP 2:
---------

Add consumer logic and Nuget package

Add Consumer queue -> SomeQueue1

#STEP 3:
---------

Add producer logic and Nuget package

Add producer Exchange -> SomeExchangeName.SomeTopic

Add one more Consumer(MicroService 3) with queue -> SomeQueue2

Add shared project with models

