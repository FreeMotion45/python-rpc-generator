from common.json_serializer import JsonSerializer
import json
from common.json_serializer import JsonSerializer

class SimpleProtocol:
    def __init__(self, serializer: JsonSerializer) -> None:
        self._serializer = serializer

    def send(self, functionName: str, functionParams: list, connection) -> None:
        function_name_bytes = functionName.encode('utf-8')
        function_name_header = len(function_name_bytes).to_bytes(4, byteorder='little')
        serialized_message = self._serializer.serialize(functionParams)
        length_header = len(serialized_message).to_bytes(4, byteorder='little')

        connection.send(function_name_header + function_name_bytes + length_header + serialized_message)

    def send_result(self, result: dict, connection):
        serialized_message = self._serializer.serialize(result)
        length_header = len(serialized_message).to_bytes(4, byteorder='little')

        connection.send(length_header + serialized_message)

    def receive(self, connection) -> dict:        
        name_length = int.from_bytes(connection.recv(4), byteorder='little')

        function_name_bytes = connection.recv(name_length)
        function_name = function_name_bytes.decode('utf-8')

        length_header = int.from_bytes(connection.recv(4), byteorder='little')
        parameters = self._serializer.deserialize(connection.recv(length_header))

        return function_name, parameters

    def receive_result(self, connection) -> dict:
        length_header = int.from_bytes(connection.recv(4), byteorder='little')
        result = self._serializer.deserialize(connection.recv(length_header))

        return result
