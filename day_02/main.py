with open('input.txt') as f:
    input = [line for line in f]


h = 0
d = 0

for line in input:
    modifier, value = line.split(' ')
    value = int(value)

    if modifier == 'forward':
        h = h + value
            
    if modifier == 'down':
        d = d + value
    
    if modifier == 'up':
        d = d - value


print("part 1:")
print(h * d)



h = 0
d = 0
a = 0


for line in input:
    modifier, value = line.split(' ')
    value = int(value)

    if modifier == 'forward':
        d = d + a * value
        h = h + value

    if modifier == 'down':
        a = a + value
    
    if modifier == 'up':
        a = a - value

print("part 2:")
print(h * d)