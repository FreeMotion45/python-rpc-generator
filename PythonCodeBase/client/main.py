from client.functions.echo import EchoCommand

server_echo = EchoCommand("Hey").execute()
print(server_echo)
