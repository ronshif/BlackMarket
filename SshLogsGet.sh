
#!/bin/bash
#This should copy the data from transaction log in the server to our machine
sshpass -p "genV1948dell" ssh -o StrictHostKeyChecking=no rachel@3.15.23.194 cat transactions.log > trans.log
