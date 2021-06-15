from common.command import AbstractCommand


class $(FUNCTION_NAME)Function(AbstractCommand):
    def __init__(self, $(FUNCTION_PARAMS)) -> None:
        super().__init__($(STRINGED_FUNCTION_NAME))
        self.params = [$(FILLED_FUNCTION_PARAMS_LIST)]
