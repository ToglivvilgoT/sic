---
_layout: landing
---

# Sic Docs

Sic is a music theory grounded node based music making tool.

## Structure of Sic

Sic is split into 4 different csproj folders:

+ **Sic** is where the business logic lies.
+ **Sic.Cli** is used for quick console testing of the Sic project.
+ [SicApp](xref:SicApp) is the frontend app logic.
+ [SicTests](xref:SicTests) is where the tests for Sic are.

### Sic

The Sic project is the biggest part of Sic. All important code lies in the [Models namespace](xref:Sic.Models). Here we find the following namespaces:

+ [Music](xref:Sic.Models.Music) is where all music classes are stored.
+ **Nodes** stores the logic for nodes used in the gui.
+ **SoundAdaptors** has logic for turning the Music classes into actual sound.
+ **TextParser** has parsers for parsing text into the different Music classes.
+ **Transformers** currently quite unused, but stores metods for transforming one music class into another.

#### Music

This folder stores all business logic for the music classes. The idea is to keep these classes as simple as possible, mainly containing constructors for each type and very simple helper methods. More complex logic for transforming music classes from one to another are stored in the **Transformers** namespace.

#### Nodes

This is the namespace containing logic for the nodes. Note that there is no gui logic here, only the logical connections and structure of nodes is stored here. The actual gui part of the nodes are kept in the **SicApp**.

#### SoundAdaptors

This namespace contains classes for turning abstract **Music** classes into actual sound. Currently this is done with the NAudio library.

#### TextParser

##### Overview

This namespace contains classes for parsing text into the different **Music** classes. The base for this is the PrimitiveParsers.IParser interface. This interface is based on the idea of an LL(1) recursive parser. Basically, based on simply looking at the next character to be parsed, the correct parser can be run. This decision is made by the AggregatedParsers.BranchingParser class.

##### Future development

As of right now, the "tryParse" method really doesn't try so much as it just crashes if a parsing error would occur when trying to parse. It would be cool if a more structured way of error handling could be added. Doesn't have to be super advanced, but just highlighting with a message what went wrong and where the error occurred. Anything better than the average c++ error message would suffice.

#### Transformers

This namespace is currently very empty, but should contain more complex transformation of **Music** classes in the future.

### Sic.Cli

Since **Sic** is a library, it can not have it's own executable main method. Instead, the **Sic.Cli** project has an executable main method that is simply used to quickly test or debug things about the Sic project by command line.

### SicApp

This is where the front end logic lies. The **NodeWindow** class is what is on screen at a certain point in time. It maintains a set of nodes, updates them based on input and renders them to the screen. The **VisualNode** class is probably the most important class of the gui app. This class adds graphical functionality on top of the logical class **Node**. The main part being having actual collision boxes that interact with the user so that nodes and connections between them can be modified.

### SicTests

SicTests is the namespace for all the tests of Sic. Most focus lies on testing the **Sic** project since it contains the most business logic.
