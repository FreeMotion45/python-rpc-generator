import json

class JsonSerializer:
    def __init__(self, unicode: str = 'utf-8') -> None:
        self.__unicode = unicode

    def serialize(self, functionParams: dict) -> bytes:
        return json.dumps(functionParams).encode(self.__unicode)

    def deserialize(self, serialized_message: bytes) -> dict:
        return json.loads(serialized_message.decode(self.__unicode))