from socket import socket, AF_INET, SOCK_STREAM
from threading import Thread
from common.json_serializer import JsonSerializer
from common.protocol import SimpleProtocol
import importlib
import os


class Server:
    def __init__(self, ip: str, port: int, protocol: SimpleProtocol = SimpleProtocol(JsonSerializer())) -> None:
        self.__ip = ip
        self.__port = port
        self.__socket = socket(AF_INET, SOCK_STREAM)
        self.__protocol: SimpleProtocol = protocol

        self.__imported_commands = {}
        self.import_commands()

    def import_commands(self) -> None:
        for command_handler_file in os.listdir("command_handlers"):
            if os.path.isfile("command_handlers/" + command_handler_file):
                print("Loading function:", command_handler_file)

                module_name = command_handler_file.split('.')[0]
                module = importlib.import_module(f"command_handlers.{module_name}")

                function_name = "_".join(command_handler_file.split('_')[:-1])
                function_class_name = f"{function_name.title()}FunctionHandler"
                function_handler_class = getattr(module, function_class_name)

                handler_instance = function_handler_class()
                self.__imported_commands[function_name] = handler_instance

    def open(self) -> None:
        self.__socket.bind((self.__ip, self.__port))

    def run(self) -> None:
        self.__socket.listen()
        print("Server listening on hostname:", self.__ip + ":" + str(self.__port))
        print("Server ready to accept connections")
        while True:
            connection, address = self.__socket.accept()
            print("Client connected")

            client_thread = Thread(target=self._handle_client, args=(connection, address))
            client_thread.start()

    def _handle_client(self, connection, address):
        function_name, parameters = self.__protocol.receive(connection)
        result = self.__imported_commands[function_name].handle(*parameters)
        self.__protocol.send_result({'result': result}, connection)


s = Server($(HOSTNAME), $(PORT))
s.open()
s.run()
