# Contributing to MeetupApi

First off, thanks for taking the time to contribute! 🎉

The following is a set of guidelines for contributing to MeetupApi. These are mostly guidelines, not rules. Use your best judgment, and feel free to propose changes to this document in a pull request.

## Code of Conduct

This project and everyone participating in it is governed by the [Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code. Please report unacceptable behavior to the project maintainers.

## How Can I Contribute?

### Reporting Bugs

This section guides you through submitting a bug report for MeetupApi. Following these guidelines helps maintainers and the community understand your report, reproduce the behavior, and find related reports.

- **Use a clear and descriptive title** for the issue to identify the problem.
- **Describe the exact steps to reproduce the problem** in as many details as possible.
- **Provide specific examples** to demonstrate the steps.
- **Describe the behavior you observed** after following the steps and point out what exactly is the problem with that behavior.
- **Explain which behavior you expected to see instead** and why.

### Suggesting Enhancements

This section guides you through submitting an enhancement suggestion for MeetupApi, including completely new features and minor improvements to existing functionality.

- **Use a clear and descriptive title** for the issue to identify the suggestion.
- **Provide a step-by-step description of the suggested enhancement** in as many details as possible.
- **Explain why this enhancement would be useful** to most MeetupApi users.

### Pull Requests

- Fill in the required template
- Do not include issue numbers in the PR title
- Include screenshots and animated GIFs in your pull request whenever possible.
- Follow the C# coding style used in the project.
- Include unit tests when you contribute new features, as they help to a) prove that your code works correctly, and b) guard against future breaking changes to verify the impact of your changes.

## Styleguides

### C# Coding Style

- Use [Allman style braces](http://en.wikipedia.org/wiki/Indent_style#Allman_style).
- Use `camelCase` for private members and use `readonly` where possible.
- Avoid `this.` unless absolutely necessary.
- Always specify the visibility, even if it's the default (i.e. `private string foo` not `string foo`).
- Namespace imports should be specified at the top of the file, outside of namespace declarations and should be sorted alphabetically, with `System.` namespaces at the top.

### Git Commit Messages

- Use the present tense ("Add feature" not "Added feature")
- Use the imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit the first line to 72 characters or less
- Reference issues and pull requests liberally after the first line
