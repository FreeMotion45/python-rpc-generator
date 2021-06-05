from common.command import AbstractCommand


class EchoCommand(AbstractCommand):
    def __init__(self, message: str) -> None: # TEMPLATE FILL PARAMS
        super().__init__("Echo") # TEMPLATE FILL NAME
        self.params = ["Echo"] # TEMAPLTE FILL ALL RECEIVED PARAMS
