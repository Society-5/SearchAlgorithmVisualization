# SearchAlgorithmVisualization

A Windows (WPF, C#) desktop app for generating mazes and visualizing path-search algorithms. It was made to experiment with the exploration strategies a robot could use to find its way around an unknown floor.

## Features

- **Maze generation.** A randomized depth-first search (recursive backtracker) carves a perfect maze of any size (set the width and height in squares). The maze is drawn on a 500×500 canvas.
- **Path search.** The UI has an algorithm picker and a Run button. Breadth-first search is planned, but `ViewModel.FindPath` is not implemented yet.

## Build

Open `WpfApp1.sln` in Visual Studio. The UI uses [MahApps.Metro](https://github.com/MahApps/MahApps.Metro), restored from NuGet.

---

Part of **[Society-5](https://github.com/Society-5)**: a WowWee Robosapien X that explores a floor on its own, using a phone camera and QR codes as markers, with a mixed-reality (VR) interface for remote control. See [Introduction](https://github.com/Society-5/Introduction) for the project overview.
