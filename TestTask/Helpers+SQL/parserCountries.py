import xml.etree.ElementTree as ET
tree = ET.parse('countries.xml')
root = tree.getroot()
i = 1
for dataClass in root.findall('country/name'):
    with open('out.txt', 'a') as f:
        f.write("({0}, '{1}'),".format(i, dataClass.text))
        f.write("\n")
    i += 1
