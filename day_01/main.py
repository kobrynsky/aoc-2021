with open('input.txt') as f:
    input = [int(line) for line in f]

increases = 0

for idx, val in enumerate(input):
    if(idx != 0 and input[idx-1] < input[idx]):
        increases += 1

print("part 1:")
print(increases)


increases = 0

last_sliding_window_index = len(input)-3

for idx, val in enumerate(input):
    if(idx == 0 or  idx > last_sliding_window_index):
        continue
    
    first_window = input[idx-1] + input[idx] + input[idx+1]
    second_window = input[idx] + input[idx+1] + input[idx+2]

    print(first_window)
    print(second_window)

    if(second_window > first_window):
        increases += 1

print("part 2:")
print(increases)
