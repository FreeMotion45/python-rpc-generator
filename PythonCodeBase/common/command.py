from socket import socket, AF_INET, SOCK_STREAM
from common.protocol import SimpleProtocol
from common.json_serializer import JsonSerializer

class AbstractCommand:
    IP = $(HOSTNAME)
    PORT = $(PORT)

    def __init__(self, function_name: str) -> None:        
        self.__function_name = function_name

    def execute(self):        
        protocol = SimpleProtocol(JsonSerializer())
        client = socket(AF_INET, SOCK_STREAM)
        client.connect((AbstractCommand.IP, AbstractCommand.PORT))

        params = self.params
        protocol.send(self.__function_name, params, client)
        result = protocol.receive_result(client)
        return result['result']
        