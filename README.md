# PasswordGenerator

A simple, fast and reliable console utility for generating cryptographically strong passwords.

---

## Features

- **Cryptographic strength:** generation is based on the `RandomNumberGenerator` cryptographic random number generator.
- **Flexible character set configuration:** ability to disable lowercase letters, uppercase letters, digits and special characters.
- **Two launch modes:**
  - **Via arguments:** instant generation with fine-tuning through short flags.
  - **Interactive:** step-by-step console wizard with quick selection via the Enter key.
- **Strict validation:** length range check (from 8 to 64 characters) and protection against invalid input.
- **No third-party dependencies:** uses only the standard library.
* **Colored output:** clear highlighting of information and warnings in the terminal.

---

## Quick Start

### Requirements

Building and running requires the [.NET 10.0 SDK](https://dotnet.microsoft.com/download).

### Build and Run

Clone the repository and navigate to the project folder.

```bash
git clone https://github.com/demurel0/password-generator.git
cd password-generator
```

---

## Usage

### Running with Arguments

You can pass only the length or combine it with flags to exclude character sets.

```bash
dotnet run --project PasswordGenerator -- [options]
```

#### Available Parameters

| Flag | Description | Default Value |
| :--- | :--- | :--- |
| `-l, --length <number>` | Password length | 16 |
| `-L, --lower` | Exclude lowercase letters | Enabled |
| `-U, --upper` | Exclude uppercase letters | Enabled |
| `-D, --digits` | Exclude digits | Enabled |
| `-S, --special` | Exclude special characters | Enabled |
| `-h, --help` | Show usage help | - |

### Interactive Mode

If you launch the utility without arguments, a step-by-step setup wizard opens. The **Enter** key automatically selects the option marked with a capital letter.

```bash
dotnet run --project PasswordGenerator
```

---

## Usage Examples

### Generation via Flags

```console
$ dotnet run --project PasswordGenerator -- -l 14 -S
Generated password: VKer5dvLG50oZt

$ dotnet run --project PasswordGenerator -- 20
Generated password: O8IV-*x(iS_zmC&FmVvg

$ dotnet run --project PasswordGenerator -- --length 12 --special
Generated password: izyw6pbd6Avc
```

With invalid arguments, the program prints a message and exits.

```console
$ dotnet run --project PasswordGenerator -- -l 100
Length must be between 8 and 64.

$ dotnet run --project PasswordGenerator -- -L -U -D -S
You cannot exclude all character sets at the same time.

$ dotnet run --project PasswordGenerator -- --unknown
Unknown argument: '--unknown'. Use '-h' or '--help' for help.
```

### Interactive Dialog

```console
$ dotnet run --project PasswordGenerator
Enter password length (8-64): 16
Include lowercase letters? [Y/n]:
Include uppercase letters? [Y/n]:
Include digits? [Y/n]:
Include special characters? [Y/n]: n

Generated password: MKzJOIqsy8aofmvL
```

If all character sets are disabled, the wizard will require selecting at least one.

```console
Include lowercase letters? [Y/n]: n
Include uppercase letters? [Y/n]: n
Include digits? [Y/n]: n
Include special characters? [Y/n]: n

Select at least one character set.
```

### Help

```console
$ dotnet run --project PasswordGenerator -- -h
┌──────────────────────┐
│  ••••••••••          │
└──────────────────────┘

USAGE
PasswordGenerator [options]

OPTIONS
  -l, --length <length>  Password length (8-64)
  -L, --lower            Exclude lowercase letters
  -U, --upper            Exclude uppercase letters
  -D, --digits           Exclude digits
  -S, --special          Exclude special characters
  -h, --help             Show help
```

---

## License

This project is distributed under the [MIT](LICENSE) license.
