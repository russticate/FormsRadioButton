# A simple Xamarin.Forms Radio Button
I needed a fast & simple radio button for Xamarin.Forms. I saw some great samples out there, but they were too complicated for my use case.

## Features
- Fast and lightweight. It is a composite control utilising the baked in Xamarin.Forms SwitchCell. High performance, no custom renderers, no bloated ViewCell and fully supported on all current Xamarin.Forms platforms.
- Targets .NET Standard 2.0 with a single dependency on Xamarin.Forms
- Full MMVM support.
- Publishes an event when the toggled item changes. You can consume this event in your code behind or use a behavior to forward it to a ViewModel.