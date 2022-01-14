## Thoughts about Exceptions vs Errors

- Clean Code : Chapter 7 : Error Handling : Page 104 : "Use Exceptions Rather Than Return Codes"
- Exceptions or errors are used to deviate applications from its happy path to exceptional ones.
- The worst about errors is that they are ignored by default, while Exceptions propagate automatically.
- Different from errors that you have to write code to take care of, with exceptions inertia will be in your favor.
- When you opt by using exceptions to report problems, caller methods don't have to check callee's return value to decide about deviating to exceptional paths.
- Exception handling removes error handling code from the main line of control flow.
- This leads to cleaner code, avoiding lots of "if"s to check the return of each method.
- Exception handling is better than the alternatives for reporting errors from constructors too!
- Constructors in particular have predefined signatures that leave no room for return codes.
- Callers should use try-finally to have a chance to dispose its own disposable elements, in the case of an exception be thrown.
- Alternative paths are different from exceptional paths, it is a conceptual matter!
- Alternative paths are closer to the happy path than the exceptional ones!
- Exceptions are not an alternative for "switch" statements, maybe you have a cenario where returning codes fits better!
- In this case, always return an interface to allow caller method to use pattern matching to select alternative paths.
- It is expected that you won't be catching lots of exceptions inside your use case.
- Most of the time you'll let them bubble up to reach some global handler outside your use case.
- In general you will have one single Exception inherited type per use case, and multiple error types to go with it.
- Maybe you will have one general Exception inherited type for common pre-conditions validations.
