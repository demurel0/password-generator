# Password Generator

A simple, fast, and reliable console utility for generating cryptographically strong passwords.

## Features

- **Cryptographic strength:** passwords are generated using the cryptographically secure random number generator `RandomNumberGenerator`.
- **Flexible character sets:** you can disable lowercase letters, uppercase letters, digits, and special characters.
- **Two launch modes:**
  - **Command-line arguments:** instant generation with fine-grained control via short flags.
  - **Interactive:** a step-by-step console dialog where pressing Enter selects the default option.
- **Strict validation:** the length range (8 to 64 characters) is checked, and invalid input is handled gracefully.
- **No third-party dependencies:** only the standard library is used.

## Quick Start

Building and running requires the [.NET 10.0 SDK](https://dotnet.microsoft.com/download).

### Clone the repository

```bash
git clone https://gitverse.ru/demurel/password-generator.git
cd password-generator
```

## Usage

### Running with arguments

You can pass just the length, or combine it with flags that exclude character sets.

```bash
dotnet run --project PasswordGenerator -- [length] [options]
```

#### Available options

| Flag | Description | Default |
| :--- | :--- | :--- |
| `-l <number>` | Password length | 16 |
| `-L` | Exclude lowercase letters | Included |
| `-U` | Exclude uppercase letters | Included |
| `-D` | Exclude digits | Included |
| `-S` | Exclude special characters | Included |
| `-h` | Show usage help | - |

### Interactive mode

If you run the utility without arguments, a step-by-step setup wizard starts. Pressing **Enter** automatically selects the option shown in uppercase.

```bash
dotnet run --project PasswordGenerator
```

## Examples

### Generating with flags

```console
$ dotnet run --project PasswordGenerator -- -l 14 -S
Generated password: 9pL3mQ8vR1xT5k

$ dotnet run --project PasswordGenerator -- -l 100
Error: Length must be between 8 and 64.
```

### Interactive dialog

```console
$ dotnet run --project PasswordGenerator
Enter password length (8-64): 16
Include lowercase letters? [Y/n]: 
Include uppercase letters? [Y/n]: 
Include digits? [Y/n]: 
Include special characters? [Y/n]: n

Generated password: vNqLk3opTwE6XzBc
```

### Help

```console
$ dotnet run --project PasswordGenerator -- -h
Password Generator

Usage: PasswordGenerator [length] [options]

-l <length>  password length (8–64)
-L           exclude lowercase
-U           exclude uppercase
-D           exclude digits
-S           exclude special characters
-h           help

No arguments - interactive mode.
All character groups are enabled by default.
```

## License

This project is licensed under the [MIT](LICENSE) license.
