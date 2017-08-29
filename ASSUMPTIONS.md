###The below assumptions have been taken###

* Project Manager is aware that this is a prototype
* Security was not given priority since this is a prototype
* The Games will not be functional
* Design was kept to the bare minimum focusing on showing instant messaging and instant updates
* The Technology used for the Front applications might not be what will be used when developing that actual applications
* Message queues where not implemented since these required a separate application to monitor the queue and would not have added any substance to prototype
* Service Fabric was also not implemented since the application can easily be presented using normal local/cloud hosting.
* JWT refresh token was not implemented, instead a long expiry time has been set. 
* .Net core proved to be a limitation due to libraries not being production ready. Some custom implementation had to be used.
* Role based authentication has been omitted from the API and will be developed for the production application