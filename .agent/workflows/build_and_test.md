---
description: Build and Test the MeetupApi project
---

1. Restore dependencies
```bash
dotnet restore
```

2. Build the project
```bash
dotnet build --no-restore
```

3. Run tests
// turbo
```bash
dotnet test --no-build --verbosity normal
```
