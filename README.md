# dijkstra_basics

> C# implementation of basic pathfinding on a grid using graph-based algorithms.

---

## Overview

A foundational pathfinding utility that converts 2D grid-based environments into graph structures and provides methods for grid-to-graph conversion and graph visualization.

---

## Usage

```csharp
var pathFinder = new PathFinder();
var grid = pathFinder.BlankGrid(5, 5);
var graph = pathFinder.BuildGraphFromGrid(grid);
pathFinder.PrintGraph(graph);
```

---

## Features

- **Grid to Graph Conversion** — Convert 2D grid arrays into adjacency-list graph representations
- **Graph Visualization** — Print graph structures to console for debugging
- **Grid Creation** — Generate blank rectangular grids with configurable dimensions
- **Node Connectivity** — Establishes connections between adjacent walkable cells (0-valued cells)

---

## License

Copyright 2023 Walter Gordy
