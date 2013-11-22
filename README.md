# CrossBase #

## Introduction ##

CrossBase is a C# code library that contains platform abstractions and utilities that a primary developed for test-ability of production code. 
Many good practices of different project are collected in this library and it is a good starting point for project that use [TDD][1]. 

## Platform abstractions ##

When following the [TDD][1] discipline strictly, you want to control the environment in which your unit tests run. 

For example the file system. If your production code directly depends on the .NET `File.Exists` method your unit tests need to do a lot of setup/tear down. The setup needs to create files and the teardown needs to delete it. Another example is time. If your production code directly depends on the `DateTime.Now` you have a hard time testing long running scenarios, event in the future, etc.

CrossBase contains the following straight forward platform abstraction components:

 - **Time** Abstracts `DateTime.Now`.
 - **FileSystem** (abstracts `File.xxxxx` and `Directorty.xxxxx`)
 - **Random** (abstracts `Random`)
 - **Logging** (abstracts logging)
 - **Threading** (abstracts threading, how to create threads)

## Inter thread communication ##

In addition to the platform abstractions, CrossBase contains more advanced components for doing inter tread communication. At the heart of these components lays a fundamental architectural choice how to deal with inter thread communication. This architecture choice is, like the choice to use platform abstractions, evolved for making production code testable.

The choice is to let all production code to be single threaded. If this succeeds, all written unit tests will be true. Consider the other way around, if your production code is not single threaded, you need to create multi threaded unit test to verify the behavior of the code. Writting multi treaded unit test is complex because it needs a lot of environement setup (creation/deletion of threads) and the number of scenarios to test explode with multiple thread executing production code.

CrossBase uses message queues to do inter thread communication. Obviously this is not some new, this approach is being used in almost all frameworks in one way or another. CrossBase uses a simple abstraction for dispatchers and contains several implementations that can be used for different kind of applications and of course for testing.

The following components are based on the CrossBase dispatchers:

 - **Timers** (abstracts .NET timers to the CrossBase dispatchers)
 - **Dispatching** (abstracts inter trhead communcation with dispatchers)

## Platform implementations ##
For the .NET, Mono a shared platform implementation exists for all the CrossBase abstractions. An add-on to the shared platform implementation exists for the WPF dispatcher


  [1]: http://en.wikipedia.org/wiki/Test-driven_development    

## State Machine ##
CrossBase contains a very testable implementation of a state machine. This state machine is a combination of a table implementation and the classic state pattern.


## Code Generation ##
CrossBase has a number of T4 code generators generate most of the scaffolding code needed when using CrossBase platform.

Please see video tutorials below for more detail.

## Installation ##

CrossBase can be install using NuGet. Note however that CrossBase is not a library package, it a source code package. This makes the code very visible and hopefully this will contribute to a shared community developemnt of CrossBase in the future.

Please see video tutorials below how to install CrossBase.


## Video's ##

[Install CrossBase using NuGet][2]


  [1]: http://en.wikipedia.org/wiki/Test-driven_development
  [2]: http://www.youtube.com/watch?v=tNsX7Nfcm60