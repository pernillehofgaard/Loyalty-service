<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Families</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content :fullscreen="true">
      <ion-header collapse="condense">
        <ion-toolbar>
          <ion-title size="large">Families</ion-title>
        </ion-toolbar>
      </ion-header>

      <ion-card v-if="families && families.length">
        <ion-card-header>
          <ion-card-title>Family Data</ion-card-title>
        </ion-card-header>
        <ion-card-content>
          <ul>
            <li v-for="(family, index) in families" :key="index">
              <p><strong>Date:</strong> {{ family.date }}</p>
              <p><strong>Coin:</strong> {{ family.coin }}</p>
              <p><strong>Summary:</strong> {{ family.summary }}</p>
              <p><strong>Temperature (F):</strong> {{ family.temperatureF }}</p>
            </li>
          </ul>
        </ion-card-content>
      </ion-card>

      <ion-card v-else>
        <ion-card-header>
          <ion-card-title>Loading...</ion-card-title>
        </ion-card-header>
        <ion-card-content>
          Please wait while we fetch the family data.
        </ion-card-content>
      </ion-card>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import {
  IonPage,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
    IonCard,
    IonCardHeader,
    IonCardTitle,
    IonCardContent,
} from "@ionic/vue";
import { ref, onMounted } from "vue";

interface Family {
  date: string;
  coin: number;
  summary: string;
  temperatureF: number;
}

const families = ref<Family[]>([]);

const fetchFamilies = async () => {
  try {
    const response = await fetch("http://localhost:5104/families");
    if (!response.ok) {
      throw new Error(`Error fetching families: ${response.statusText}`);
    }
    families.value = await response.json();
  } catch (error) {
    console.error("Error fetching families:", error);
  }
};

onMounted(fetchFamilies);
</script>