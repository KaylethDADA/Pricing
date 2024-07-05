import React, { useState, useEffect } from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';

export default function App() {
  const [data, setData] = useState('');
  const [error, setError] = useState(null);

  const fetchGetInfo = async () => {
    try {
      const response = await fetch('http://localhost:5000/api/pricing/getinfo', 
        {
          method:'get'
        });
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      const result = await response.json();
      setData(result);  
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchGetInfo();
  }, []);

  return (
    <View style={styles.container}>
      {error ? (
        <Text>Error: {error}</Text>
      ) : (
        <Text>{data}</Text>
      )}
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});