import json

with open('Vandvejen.txt') as f:
    lines = f.readlines()

position = 0
points = []


for line in lines[1:] : 
    arr = line.split('\t')
    latitude = arr[1]
    longitude = arr[2].replace('\n', '')
    position+=1
    dictionary ={
    "position" : position,
    "latitude" : latitude,
    "longitude" : longitude,
    }
    points.append(dictionary)

json_object = json.dumps(points)

with open("route.json", "w") as outfile:
    outfile.write(json_object)
