import paramiko
#not finished

ssh = paramiko.SSHClient()
ssh.set_missing_host_key_policy(paramiko.AutoAddPolicy())
ssh.connect('3.15.23.194',username='rachel',password='genV1948dell')
stdin,sdtout,stderr = ssh.exec_command("cat tarnsacitons.log")
print(ssh_stdout.read())
