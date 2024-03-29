import copy

class TestCase:

    def __init__(self, name: str, params: list = None, result: any = None, disabled: bool = False):
        self.name = name
        self.params = params if params else []
        self.result = result
        self.disabled = disabled

    def Param(self, param: any):
        self.params.append(param)
        return self
    
    def Result(self, result):
        if self.result:
            raise ValueError(result)

        self.result = result
        return self

    def Disable(self, disabled: bool):
        self.disabled = disabled
        return self
    
    def __str__(self) -> str:
        return f"Params: {str(self.params)}, Expected: {self.result}"

    def Clone(self, name: str):
        return TestCase(name, copy.deepcopy(self.params), self.result, self.disabled)