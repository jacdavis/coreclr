// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// non-empty stack before switch

.assembly extern legacy library mscorlib {}
.assembly 'switch11'
{
  
  
}

.module 'switch11.exe'

.class public auto ansi Test
       extends ['mscorlib']System.Object
{
  .method public hidebysig static void Main() il managed
  {
    .entrypoint
    .maxstack  8
              ldc.i4.5
    IL_0000:  br.s       IL_0002

    IL_0002:  br.s       IL_0004

    IL_0004:  ldc.i4.s   100
    IL_0006:  call       void ['mscorlib']System.Environment::set_ExitCode(int32)
    IL_000b:  ldstr      "Test passed"
    IL_0010:  call       void ['mscorlib']System.Console::WriteLine(class System.String)
    IL_0015:  pop
              call       int32 ['mscorlib']System.Environment::get_ExitCode()
              call       void ['mscorlib']System.Environment::Exit(int32)
              ret
  } 

} 
