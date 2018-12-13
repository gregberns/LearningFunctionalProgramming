# Higher Order Functions in PureScript

## Purpose

The purpose of this code is to introduce Higher Order Functions using the PureScript language

## Getting Setup

### Prerequisite

Install a **modern** version of Node JS

### Install PureScript

```
npm install -g purescript
```

If this fails, see `Installing Purescript without NPM`.

#### Installing Purescript without NPM

If this fails, precompiled binaries are available for OSX, Linux, and Windows from the [latest release](https://github.com/purescript/purescript/releases) page on GitHub.

##### Windows

* Download binary to a folder location
  * Download the [latest release](https://github.com/purescript/purescript/releases) `win64.tar.gz` file.
  * Get 7Zip or a program to unpack a tarball (`*.tar.gz` file)
  * Extract the `win64.tar.gz` file with 7Zip
  * Create folder `C:\bin\purescript`
  * Copy extracted files into the `purescript` folder
* Add binary folder to path
  * Open the Start menu, type in 'path', and select the `Edit the environmental variables for your account` option
  * Add the binary location to the end of the `Path` variable: `;C:\bin\purescript`
  * Press 'Ok' to save settings
* Open a new console window, type `purs.exe`. Ensure that it can be accessed from any folder.

### Install Pulp and Bower

```
npm install -g pulp bower
```

### Clone this Project

```
git clone https://github.com/gregberns/LearningFunctionalProgramming/
```

### Open the REPL

```
> cd LearningFunctionalProgramming/FunctionalExamples/HigherOrderFunctions/purescript
> psc-package build
> pulp repl
```

If the command fails with the error below, make sure `purs.exe` is available on your path.

```
The system cannot find the path specified.
* ERROR: Subcommand terminated with exit code 1
```

### Next Steps

Note: If using VSCode, there are two plugins that might be helpful: `PureScript IDE` and `PureScript Language Support`

Once in the REPL these commands will be helpful

```
:r  - will recompile your program
:q  - will exit you out of the REPL
```

## Doing the Examples

In your favorite text editor, open the `purescript` directory.

To get familiar with syntax, start here:

```
src/BasicSyntax.purs
```

Then move onto:

```
src/HigherOrderFunctions.purs
src/HOFInPractice.purs
src/ApplyTransactions.purs
```
