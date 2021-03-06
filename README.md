## Thoughts about Exceptions vs Errors

- Clean Code : Chapter 7 : Error Handling : Page 104 : "Use Exceptions Rather Than Return Codes"
- Exceptions and errors are used to deviate program flow from its happy path to exceptional ones.
- One bad thing about errors is that they can be ignored by default, while Exceptions propagate automatically.
- With errors you have to write code to take care of, with exceptions inertia will be in your favor.
- When you opt by using exceptions to report problems, caller methods don't have to check callee's return value to go through exceptional paths.
- Exception handling removes error handling code from the main line of control flow.
- This leads to cleaner code, avoiding lots of "if"s to check the return of each method.
- Exception handling is better than the alternatives for reporting errors from constructors too!
- Constructors in particular have predefined signatures that leave no room for return codes.
- Callers should use try-finally to have a chance to dispose its own disposable elements, in the case of an exception be thrown.
- Alternative paths are different from exceptional paths, it is a conceptual matter!
- But alternative paths are generally triggererd by exceptions or errors in the happy path!
- Exceptions are not an alternative for "switch" statements
- So maybe you have a cenario where returning codes fits better!
- In this case, always return an interface to allow caller method to use pattern matching to choose between alternatives.
- It is expected that you won't be catching lots of exceptions inside your use case.
- Most of the time you'll let them bubble up to reach some global handler outside your use case.
- In general you will have one single Exception inherited type per use case, and multiple error types to go with it.
- Most likely you will have some abstract or concrete types, Exception inherited, for common pre-conditions like NotFoundException, UnauthorizedException, DomainException.
- Also you may have one concrete type, Exception inherited, for common model validations like ModelValidationException.
- All your exceptions and errors must have a way be uniquely identified by consumers
- For Web API projects, there is this RFC7807 that defines "a way to carry machine-readable details of errors in a HTTP response".
