# -*- coding: utf-8 -*-
"""
Created on Thu Nov 12 10:25:02 2020

@author: walter
"""

import sys
import math
import numpy as np
import random
import time
import copy


def print_grid(grid_to_draw):
    for ry in grid_to_draw:
        for cx in ry:
            print(int(cx), end=" ")
        print("")


def build_np_graph(grid):
    graph = {}
    height = grid.shape[0]
    width = grid.shape[1]
    grid_nodes = np.arange(width * height).reshape(grid.shape)
    for i in range(height):
        for j in range(width):
            node = grid_nodes[i,j]
            child_nodes = {}
            mul = 1
            if i - 1 >= 0:
                if grid[i-1, j] == 0:
                    child_nodes[grid_nodes[i-1, j]] = mul
            if i + 1 < height:
                if grid[i+1, j] == 0:
                    child_nodes[grid_nodes[i+1, j]] = mul
            if j - 1 >= 0:
                if grid[i, j-1] == 0:
                    child_nodes[grid_nodes[i, j-1]] = mul
            if j + 1 < width:
                if grid[i, j+1] == 0:
                    child_nodes[grid_nodes[i, j+1]] = mul
            graph[node] = child_nodes
    return graph

def dijkstra(graph,start,goal):
    shortest_distance = {}
    predecessor = {}
    unseenNodes = graph
    infinity = 100
    path = []

    for node in unseenNodes:
        shortest_distance[node] = infinity

    shortest_distance[start] = 0

    while unseenNodes:
        minNode = None
        for node in unseenNodes:
            if minNode is None:
                minNode = node
            elif shortest_distance[node] < shortest_distance[minNode]:
                minNode = node

        for childNode, weight in graph[minNode].items():
            if weight + shortest_distance[minNode] < shortest_distance[childNode]:
                shortest_distance[childNode] = weight + shortest_distance[minNode]
                predecessor[childNode] = minNode

        unseenNodes.pop(minNode)

    currentNode = goal
    while currentNode != start:
        try:
            path.insert(0, currentNode)
            currentNode = predecessor[currentNode]
        except:
            path = None
            break

    if path is not None:
        path.insert(0, start)

    return path

def get_cell_num(r, c, shape):
    return r * shape[1] + c

def get_row_col(cell, shape):
    r = cell // shape[1]
    c = cell % shape[1]
    return r, c


print("Maze")
grid = np.zeros(shape=(50,50), dtype=int)
print_grid(grid)

graph = build_np_graph(grid)

path = dijkstra(graph, get_cell_num(0,0, grid.shape), get_cell_num(3, 3, grid.shape))

print("Path Taken")
print(path)
draw_grid = grid.copy()

for cell in path:
    
    position = get_row_col(cell, grid.shape)
    draw_grid[position] = 2
    
print_grid(draw_grid)
